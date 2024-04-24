import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    { path: 'wedding', data: { breadcrumb: 'Wedding' }, loadChildren: () => import('./wedding-management/wedding-management.module').then(m => m.WeddingManagementModule) },
    { path: 'event', data: { breadcrumb: 'Event' }, loadChildren: () => import('./event-management/event-management.module').then(m => m.EventManagementModule) },
    { path: 'service', data: { breadcrumb: 'Service' }, loadChildren: () => import('./service-management/service-management.module').then(m => m.ServiceManagementModule) },
    { path: 'blog', data: { breadcrumb: 'Blog' }, loadChildren: () => import('./blog-management/blog-management.module').then(m => m.BlogManagementModule) },
    { path: '**', redirectTo: '/notfound' }
])],
  exports: [RouterModule]
})
export class ManagementRoutingModule { }
