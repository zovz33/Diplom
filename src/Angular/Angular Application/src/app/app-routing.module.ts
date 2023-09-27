import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomePageComponent } from './pages/home-page/home-page.component';  
import { LoginComponent } from './pages/login/login.component';  
import { SignUpComponent } from './pages/sign-up/sign-up.component';  

const routes: Routes = [
  { path: 'home', component: HomePageComponent } ,
  { path: 'login', component: LoginComponent } ,
  { path: 'signup', component: SignUpComponent } ,
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }