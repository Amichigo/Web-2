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
    lessonName: string;
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
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, event);
    }

    reloadList(lessonName,event?: LazyLoadEvent): void {
        this._lessonService.getLessonsByFilter("read & write",lessonName, null, this.primengTableHelper.getMaxResultCount(this.paginator, event)
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
    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.lessonName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }
}
