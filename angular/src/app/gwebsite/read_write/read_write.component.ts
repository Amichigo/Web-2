import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router, Route } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { LessonDto,LessonServiceProxy } from '@shared/service-proxies/service-proxies';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/primeng';
import { CreateOrEditRWLessonModalComponent } from './create-or-edit-read-write-lesson.component';

@Component({
    templateUrl: './read_write.component.html',
    animations: [appModuleAnimation()],
    styleUrls:['./background-animation.css']
})
export class ReadWriteComponent extends AppComponentBase implements OnInit {
    lessons: LessonDto[] = [];
    chosenTopic: string;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditRWLessonModalComponent;
    constructor(
        injector: Injector,
        private _lessonService: LessonServiceProxy
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
    }

    createLesson(): void {
        this.createOrEditModal.show();
    }

    getReadWriteLessons(event?: LazyLoadEvent): void {
        this._lessonService.getLessonsByFilter("read & write", null, this.primengTableHelper.getMaxResultCount(this.paginator, event)
            , this.primengTableHelper.getSkipCount(this.paginator, event)).subscribe(result => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            })
    }

    getTypeFromLessonLink(link: string): string {
        let stringArr = link.split('/');
        return stringArr[1];
    }

    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    deleteLesson(id): void {
        this._lessonService.deleteLesson(id).subscribe(() => {
            this.reloadPage();
        })
    }
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }
}
