import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { CategoryServiceProxy, CategoryDto } from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: './category.component.html',
    animations: [appModuleAnimation()]
})
export class CategoryComponent extends AppComponentBase implements OnInit {

    categories: CategoryDto[] = [];

    constructor(
        injector: Injector,
        private _catService: CategoryServiceProxy,
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
        this.getCategories();
    }

    getCategories(): void {
        this._catService.getCategoriesByFilter(null, null, 4, 0).subscribe(result => {
            this.categories = result.items;
        })
    }
}
