import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WeddingListComponent } from './wedding-list.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
		{ path: '', component: WeddingListComponent }
	])],
  exports: [RouterModule]
})
export class WeddingListRoutingModule { }
