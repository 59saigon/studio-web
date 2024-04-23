import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    { path: 'wedding', data: { breadcrumb: 'Wedding' }, loadChildren: () => import('./wedding-management/wedding-management.module').then(m => m.WeddingManagementModule) },
    { path: '**', redirectTo: '/notfound' }
])],
  exports: [RouterModule]
})
export class ManagementRoutingModule { }
