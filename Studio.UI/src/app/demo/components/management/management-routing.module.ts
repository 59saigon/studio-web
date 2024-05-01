import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    { path: 'wedding', data: { breadcrumb: 'Wedding' }, loadChildren: () => import('./wedding-management/wedding-management.module').then(m => m.WeddingManagementModule) },
    { path: 'event', data: { breadcrumb: 'Event' }, loadChildren: () => import('./event-management/event-management.module').then(m => m.EventManagementModule) },
    { path: 'service', data: { breadcrumb: 'Service' }, loadChildren: () => import('./service-management/service-management.module').then(m => m.ServiceManagementModule) },
    { path: 'country', data: { breadcrumb: 'Country' }, loadChildren: () => import('./country-management/country-management.module').then(m => m.CountryManagementModule) },
    { path: 'city', data: { breadcrumb: 'City' }, loadChildren: () => import('./city-management/city-management.module').then(m => m.CityManagementModule) },
    { path: 'blog', data: { breadcrumb: 'Blog' }, loadChildren: () => import('./blog-management/blog-management.module').then(m => m.BlogManagementModule) },
    { path: 'photo', data: { breadcrumb: 'Photo' }, loadChildren: () => import('./photo-management/photo-management.module').then(m => m.PhotoManagementModule) },
    { path: '**', redirectTo: '/notfound' }
])],
  exports: [RouterModule]
})
export class ManagementRoutingModule { }
