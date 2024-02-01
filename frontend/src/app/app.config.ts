import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core'; 


// ---- material ----
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';  
import { MatMenuModule } from '@angular/material/menu';  
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
// ---- components ----

import { HomePageComponent } from './pages/home-page/home-page.component';
import { LoginComponent } from './pages/login/login.component';
import { SignUpComponent } from './pages/sign-up/sign-up.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { CutTextPipe } from './pipes/cuttext/cut-text.pipe';
import { SortDataPipe } from './pipes/sortdata/sort-data.pipe';
 
// ---- routes ----

import { routes, AppRoutingModule } from './app.routes';
import { TitleCasePipe } from '@angular/common'; 
import { HttpClientModule } from '@angular/common/http'; 
import { ParentComponent } from './pages/parent/parent.component';

@NgModule({
	declarations:  [
   //  provideRouter(routes),
	ParentComponent,
    HomePageComponent,
    LoginComponent,
    SignUpComponent,
    NavigationComponent,
    CutTextPipe,
    SortDataPipe,

  ],
  imports: [
	BrowserModule,
	AppRoutingModule,
	FormsModule,
	HttpClientModule, 
	TitleCasePipe,
	BrowserModule,
	BrowserAnimationsModule,
	MatToolbarModule,
	MatSlideToggleModule,
	MatIconModule,
	MatButtonModule,
	FormsModule,
	MatMenuModule
 ],
 providers: [],
  bootstrap: [ParentComponent]
})

export class AppModule { }