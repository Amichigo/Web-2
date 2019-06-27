import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LessonForViewDto, LessonServiceProxy, ArticleInput, ArticleServiceProxy, GetCurrentLoginInformationsOutput, GetUserForEditOutput, SessionServiceProxy, UserServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
    selector:'read-write-lesson',
    templateUrl: './read_write_lesson.component.html',
    animations: [appModuleAnimation()]
})
export class ReadWriteLessonComponent extends AppComponentBase implements OnInit {
    lesson: LessonForViewDto = new LessonForViewDto();
    article: ArticleInput = new ArticleInput();
    currentSession: GetCurrentLoginInformationsOutput = new GetCurrentLoginInformationsOutput();
    type: string = "";
    id: string = "";
    saving: boolean = false;
    constructor(
        injector: Injector,
        private _lessonService: LessonServiceProxy,
        private _sessionService: SessionServiceProxy,
        private _articleService: ArticleServiceProxy,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
        this._sessionService.getCurrentLoginInformations().subscribe(result => {
            this.currentSession = result;
        })
        this.init();
    }

    getLesson(id: number): void {
        this._lessonService.getLessonForEdit(id).subscribe(result => {
            this.lesson = result;
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.id = params['id'] || '';
            this.getLesson(parseInt(this.id));
        });
    }

    getTypeFromLessonLink(link: string): string {
        let stringArr = link.split('/');
        return stringArr[1];
    }

    save(): void {
        let input = this.article;
        this.saving = true;
        input.catName = this.lesson.catName;
        input.topic = this.lesson.lessonContent;
        input.userId = this.currentSession.user.id;
        this._articleService.createOrEditArticle(input).subscribe(result => {
            this.notify.info(this.l('Saved Successfully'));
        })
    }

    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
