import { CustomerServiceProxy, CategoryServiceProxy, LessonServiceProxy, ArticleServiceProxy } from './../../shared/service-proxies/service-proxies';
import { ViewDemoModelModalComponent } from './demo-model/view-demo-model-modal.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { FileUploadModule } from 'ng2-file-upload';
import { ModalModule, PopoverModule, TabsModule, TooltipModule } from 'ngx-bootstrap';
import { AutoCompleteModule, EditorModule, FileUploadModule as PrimeNgFileUploadModule, InputMaskModule, PaginatorModule } from 'primeng/primeng';
import { TableModule } from 'primeng/table';
import { GWebsiteRoutingModule } from './gwebsite-routing.module';

import { MenuClientComponent, CreateOrEditMenuClientModalComponent } from './index';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CreateOrEditDemoModelModalComponent } from './demo-model/create-or-edit-demo-model-modal.component';
import { DemoModelServiceProxy } from '@shared/service-proxies/service-proxies';
import { CustomerComponent } from './customer/customer.component';
import { ViewCustomerModalComponent } from './customer/view-customer-modal.component';
import { CreateOrEditCustomerModalComponent } from './customer/create-or-edit-customer-modal.component';
import { ReadWriteComponent } from './read_write/read_write.component';
import { ReadWriteLessonComponent } from './read_write_lesson/read_write_lesson.component';
import { CreateOrEditRWLessonModalComponent } from './read_write/create-or-edit-read-write-lesson.component';
import { GrammarVocabComponent } from './grammar_vocab/grammar_vocab.component';
import { GrammarVocabLessonComponent } from './grammar_vocab_lesson/grammar_vocab_lesson.component';
import { CreateOrEditGVLessonModalComponent } from './grammar_vocab/create-or-edit-grammar-vocab-lesson.component';
import { ArticleComponent } from './article/article.component';
import { CategoryComponent } from './category/category.component';
import { ListenWatchComponent } from './ListenWatch/listenwatch.component';
import { ViewListenWatchComponent } from './ListenWatch/view-listenwatch.component';

import {VgCoreModule} from 'videogular2/core';
import {VgControlsModule} from 'videogular2/controls';
import {VgOverlayPlayModule} from 'videogular2/overlay-play';
import {VgBufferingModule} from 'videogular2/buffering';

@NgModule({
    imports: [
        FormsModule,
        CommonModule,
        FileUploadModule,
        ModalModule.forRoot(),
        TabsModule.forRoot(),
        TooltipModule.forRoot(),
        PopoverModule.forRoot(),
        GWebsiteRoutingModule,
        UtilsModule,
        AppCommonModule,
        TableModule,
        PaginatorModule,
        PrimeNgFileUploadModule,
        AutoCompleteModule,
        EditorModule,
        InputMaskModule,
		VgCoreModule,
        VgControlsModule,
        VgOverlayPlayModule,
        VgBufferingModule
    ],
    declarations: [
        MenuClientComponent, CreateOrEditMenuClientModalComponent,
        DemoModelComponent, CreateOrEditDemoModelModalComponent, ViewDemoModelModalComponent,
        CustomerComponent, CreateOrEditCustomerModalComponent, ViewCustomerModalComponent,
        CategoryComponent,
        ReadWriteComponent,
        ArticleComponent,
        ReadWriteLessonComponent,CreateOrEditRWLessonModalComponent,
        GrammarVocabComponent,
        GrammarVocabLessonComponent,CreateOrEditGVLessonModalComponent,

        ListenWatchComponent,ViewListenWatchComponent
    ],
    providers: [
        DemoModelServiceProxy,
        CustomerServiceProxy,
        CategoryServiceProxy,
        LessonServiceProxy,
        ArticleServiceProxy
    ]
})
export class GWebsiteModule { }
