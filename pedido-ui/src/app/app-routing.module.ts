import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LancheComponent } from './lanche/lanche.component';

const routes: Routes = [
  { path: 'lanche', component: LancheComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
