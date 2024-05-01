import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', data: { breadcrumb: '' }, loadChildren: () => import('./photo-list/photo-list.module').then(m => m.PhotoListModule) },
    { path: '**', redirectTo: '/notfound' }
])],
  exports: [RouterModule]
})
export class PhotoManagementRoutingModule { }
