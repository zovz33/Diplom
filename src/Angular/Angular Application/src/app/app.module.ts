import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';  
import { MatMenuModule } from '@angular/material/menu';  
 
// ----components ----

import { HomePageComponent } from './pages/home-page/home-page.component';
import { LoginComponent } from './pages/login/login.component';
import { SignUpComponent } from './pages/sign-up/sign-up.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { CutTextPipe } from './pipes/cuttext/cut-text.pipe';
import { SortDataPipe } from './pipes/sortdata/sort-data.pipe';
 
// ---- services ----

@NgModule({
  declarations: [
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
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    FormsModule,
    MatMenuModule
  ],
  providers:  [],
  bootstrap: [HomePageComponent]
})
export class AppModule { }
