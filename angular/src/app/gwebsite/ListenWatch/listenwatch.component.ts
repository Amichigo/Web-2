import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { LessonServiceProxy, LessonDto } from '@shared/service-proxies/service-proxies';
import {Globals} from '@app/globals';
import {ViewListenWatchComponent} from './view-listenwatch.component';

@Component({
    templateUrl: './listenwatch.component.html',
    animations: [appModuleAnimation()]
})
export class ListenWatchComponent extends AppComponentBase implements OnInit {

    @ViewChild('viewListenWatch') viewListenWatch: ViewListenWatchComponent;

    lessons: LessonDto[] = [];

    constructor(
        private globals: Globals,
        injector: Injector,
        private _catService: LessonServiceProxy
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
        this.getLesson();
    }

    getLesson(): void {
        this._catService.getLessonsByFilter("listen & watch", null, 9, 0).subscribe(result => {
            this.lessons = result.items;
        
        })
    }
}
