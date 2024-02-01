import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';  
import { MatMenuModule } from '@angular/material/menu';  
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-navigation',
//   standalone: true,
//   imports: [
// 	MatToolbarModule,
// 	MatIconModule,
// 	MatButtonModule,
// 	FormsModule,
// 	BrowserAnimationsModule,
// 	MatMenuModule,
// 	MatSlideToggleModule,
// 	RouterOutlet, CommonModule
//  ],
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css'],
})
export class NavigationComponent { 
	
}