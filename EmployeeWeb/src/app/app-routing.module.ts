import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './pages/register/register.component';
import { HomeComponent } from './pages/home/home.component';
import { EditComponent } from './pages/edit/edit.component';
import { DetailComponent } from './pages/detail/detail.component';

const routes: Routes = [
  {path: '', component: HomeComponent },
  {path: 'register', component: RegisterComponent },
  {path: 'edit/:id', component: EditComponent },
  {path: 'detail/:id', component: DetailComponent }
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
