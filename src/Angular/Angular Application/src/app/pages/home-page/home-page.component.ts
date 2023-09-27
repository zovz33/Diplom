import { Component } from '@angular/core';
import { LoggerService } from 'src/app/services/logger.service';
 
@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})

export class HomePageComponent {
  HomePageTittle = 'Главная';
  fontColor = 'blue';
  sayHelloId = 1;
  canClick = false;
  message = 'Hello, World';

  sayMessage() {
      alert(this.message);
  }
}

