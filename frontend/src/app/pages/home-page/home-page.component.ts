import { LoginComponent } from './../login/login.component';
import { NavigationComponent } from './../../components/navigation/navigation.component';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router'; 

@Component({
	selector: 'app-home-page',
	// standalone: true,
	// imports: [
	//   // Move 'HomePageComponent' to the first import
	//   HomePageComponent,
	//   NavigationComponent,
	//   CommonModule,
	//   RouterOutlet, LoginComponent
	// ],
	templateUrl: './home-page.component.html',
	styleUrls: ['./home-page.component.css'],
 })
export class HomePageComponent {
  HomePageTitle = 'Главная';
}