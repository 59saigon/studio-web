import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PhotoListComponent } from './photo-list.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
		{ path: '', component: PhotoListComponent },
    { path: '**', redirectTo: '/notfound' }
	])],
  exports: [RouterModule]
})
export class PhotoListRoutingModule { }
