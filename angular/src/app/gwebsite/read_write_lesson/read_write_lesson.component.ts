import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LessonForViewDto, LessonServiceProxy, ArticleInput, ArticleServiceProxy, GetCurrentLoginInformationsOutput, GetUserForEditOutput, SessionServiceProxy, UserServiceProxy } from '@shared/service-proxies/service-proxies';
import { ArticleComponent } from '../article/article.component';

@Component({
    selector: 'read-write-lesson',
    templateUrl: './read_write_lesson.component.html',
    animations: [appModuleAnimation()],
    styles: ['.disapear{display:none}']
})
export class ReadWriteLessonComponent extends AppComponentBase implements AfterViewInit, OnInit {
    lesson: LessonForViewDto = new LessonForViewDto();
    article: ArticleInput = new ArticleInput();
    defaultMarkValue:string = "not marked"
    isDefined: boolean = false;
    currentSession: GetCurrentLoginInformationsOutput = new GetCurrentLoginInformationsOutput();
    @ViewChild('articleSection') articleSection: ArticleComponent;
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

    ngAfterViewInit(): void {
    }

    topicIsDefined(): boolean {
        if (this.lesson.lessonContent != null) {
            return true;
        }
        else return false;
    }

    getLesson(id: number): void {
        this._lessonService.getLessonForEdit(id).subscribe(result => {
            this.lesson = result;
            this.type = this.getTypeFromLessonLink(this.lesson.link);
            console.log(this.type);
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
        console.log(this.article.content);
        this.saving = true;
        input.catName = this.lesson.catName;
        input.topic = this.lesson.lessonContent;
        input.userId = this.currentSession.user.id;
        input.mark = this.defaultMarkValue;
        this._articleService.createOrEditArticle(input).subscribe(result => {
            this.notify.info(this.l('Saved Successfully'));
            this.saving = false;
        })
    }

    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
