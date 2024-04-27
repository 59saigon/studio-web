import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', data: { breadcrumb: '' }, loadChildren: () => import('./city-list/city-list.module').then(m => m.CityListModule) },
    { path: '**', redirectTo: '/notfound' }
])],
  exports: [RouterModule]
})
export class CityManagementRoutingModule { }
