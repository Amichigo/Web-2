import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, Output, EventEmitter, Input } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ArticleServiceProxy, ArticleDto } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    templateUrl: './article.component.html',
    selector:'article-section',
    animations: [appModuleAnimation()]
})
export class ArticleComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    selectedArticle: ArticleDto = new ArticleDto();
    @ViewChild('mark') modal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    /**
     * tạo các biến dể filters
     */
    @Input() articleName: string;
    articleMark: number;
    constructor(
        injector: Injector,
        private _articleService: ArticleServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
    }

    /**
     * Hàm get danh sách Article
     * @param event
     */
    getArticles(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(this.articleName, event);

    }

    reloadList(articleName, event?: LazyLoadEvent) {
        this._articleService.getArticlesByFilter(articleName,null, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteArticle(id): void {
        this._articleService.deleteArticle(id).subscribe(() => {
            this.reloadPage();
        })
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    ArticleSelected(input): void {
        this.selectedArticle = input;
        console.log(this.selectedArticle);
    }

    save(): void {
        let input = this.selectedArticle;
        input.mark = this.articleMark.toString();
        this._articleService.createOrEditArticle(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.modal.hide();
            this.reloadPage();
        })
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
