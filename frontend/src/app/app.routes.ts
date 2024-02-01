import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'; 

import { HomePageComponent } from './pages/home-page/home-page.component';  
import { LoginComponent } from './pages/login/login.component';  
import { SignUpComponent } from './pages/sign-up/sign-up.component';  
import { NavigationComponent } from './components/navigation/navigation.component';
import { NotFoundComponent } from './components/navigation/errors/not-found/not-found.component';

export const routes: Routes = [
// {
// 	path:'',
// 	redirectTo:'login',
// 	pathMatch:'full'
// },	
{ 
	path: '', component: HomePageComponent,
	children: [
	{ path: 'nav', component: NavigationComponent } ,
	// { path: 'login', component: LoginComponent } ,
	// { path: 'signup', component: SignUpComponent } ,
]} ,

	{ path: 'login', component: LoginComponent } ,
	{ path: 'signup', component: SignUpComponent } ,
	{ path: 'not-found', component: NotFoundComponent },
	{ path: '**', component: NotFoundComponent, pathMatch: 'full' }
]; 
@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
 })
 export class AppRoutingModule { }