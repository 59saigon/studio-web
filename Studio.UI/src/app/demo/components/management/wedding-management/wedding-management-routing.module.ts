import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WeddingListComponent } from './wedding-list/wedding-list.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', data: { breadcrumb: '' }, loadChildren: () => import('./wedding-list/wedding-list.module').then(m => m.WeddingListModule) },
    { path: 'create', data: { breadcrumb: '' }, loadChildren: () => import('./wedding-create/wedding-create.module').then(m => m.WeddingCreateModule) },
    { path: '**', redirectTo: '/notfound' }
])],
})
export class WeddingManagementRoutingModule { }
