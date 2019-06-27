import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router, Route } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { LessonDto,LessonServiceProxy } from '@shared/service-proxies/service-proxies';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/primeng';

@Component({
    templateUrl: './read_write.component.html',
    animations: [appModuleAnimation()],
})
export class ReadWriteComponent extends AppComponentBase implements OnInit {
    lessons: LessonDto[] = [];
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
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

    getReadWriteLessons(event?: LazyLoadEvent): void {
        this._lessonService.getLessonsByFilter("read & write", null, this.primengTableHelper.getMaxResultCount(this.paginator, event)
            , this.primengTableHelper.getSkipCount(this.paginator, event)).subscribe(result => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            })
    }

    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
