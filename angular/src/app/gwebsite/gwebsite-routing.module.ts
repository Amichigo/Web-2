import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CustomerComponent } from './customer/customer.component';
import { CategoryComponent } from './category/category.component';
import { ReadWriteComponent } from './read_write/read_write.component';
import { ReadWriteLessonComponent } from './read_write_lesson/read_write_lesson.component';


@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    {
                        path: 'menu-client', component: MenuClientComponent,
                        data: { permission: 'Pages.Administration.MenuClient' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'demo-model', component: DemoModelComponent,
                        data: { permission: 'Pages.Administration.DemoModel' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'customer', component: CustomerComponent,
                        data: { permission: 'Pages.Administration.Customer' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'category', component: CategoryComponent,
                        data: { permission: 'Pages.Administration.Category' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'read_write', component: ReadWriteComponent,
                        data: { permission: 'Pages.Administration.Category' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'read_write_lesson/:id', component: ReadWriteLessonComponent,
                        data: { permission: 'Pages.Administration.Lesson' }
                    },
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class GWebsiteRoutingModule { }
