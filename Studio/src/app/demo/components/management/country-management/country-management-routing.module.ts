import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', data: { breadcrumb: '' }, loadChildren: () => import('./country-list/country-list.module').then(m => m.CountryListModule) },
    { path: '**', redirectTo: '/notfound' }
])],
  exports: [RouterModule]
})
export class CountryManagementRoutingModule { }
