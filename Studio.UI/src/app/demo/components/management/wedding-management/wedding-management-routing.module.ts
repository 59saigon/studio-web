import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', data: { breadcrumb: '' }, loadChildren: () => import('./wedding-list/wedding-list.module').then(m => m.WeddingListModule) },
    { path: '**', redirectTo: '/notfound' }
])],
})
export class WeddingManagementRoutingModule { }
