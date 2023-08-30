import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomePageComponent } from './components/home-page/home-page.component';  
import { LoginComponent } from './components/login/login.component';  
import { SignUpComponent } from './components/sign-up/sign-up.component';  

const routes: Routes = [
  { path: 'Home', component: HomePageComponent } ,
  { path: 'Login', component: LoginComponent } ,
  { path: 'SignUp', component: SignUpComponent } ,
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }