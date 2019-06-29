import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { LessonServiceProxy, LessonInput } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewListenWatch',
    templateUrl: './view-listenwatch.component.html',
    //animations: [appModuleAnimation()]
})
export class ViewListenWatchComponent extends AppComponentBase{
    @ViewChild('viewModal') modal: ModalDirective;

    @ViewChild('videoPlayer') videoplayer: ElementRef;

    toggleVideo(event: any) {
        this.videoplayer.nativeElement.play();
    }

    private linkvideo: string;
    private content: string;
    private id: number;

    constructor(
        injector: Injector,
        private _catService: LessonServiceProxy
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */

    show(customerId?: number | null | undefined): void {
           this._catService.getLessonForEdit(customerId).subscribe(result => {
                this.linkvideo = result.link;
                this.content = result.lessonContent;
                this.id = result.id;

                this.modal.show();
            })    
    }

    close() : void{
        this.linkvideo=null;
        this.content=null;
        this.id=null;
        this.modal.hide();
    }

    changeId() {
        this.id = 0;
     }

}
