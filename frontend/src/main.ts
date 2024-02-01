import { Component } from '@angular/core'; 
import { bootstrapApplication } from '@angular/platform-browser';
import { AppModule } from './app/app.config'; 
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { ParentComponent } from './app/pages/parent/parent.component'


platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));

// bootstrapApplication(ParentComponent, appConfig)
//   .catch((err) => console.error(err));
