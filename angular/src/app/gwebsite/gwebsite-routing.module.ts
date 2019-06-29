import { NgModule } from '@angular/core';
import { RouterModule,Router } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CustomerComponent } from './customer/customer.component';
import { CategoryComponent } from './category/category.component';
import {ListenWatchComponent} from './ListenWatch/listenwatch.component';

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
                        path: 'listenwatch', component: ListenWatchComponent,
                        data: { permission: 'Pages.Administration.Lesson' }
                    },
                ]
            },

        ])
    ],
    exports: [
        RouterModule
    ]
})
export class GWebsiteRoutingModule { }
