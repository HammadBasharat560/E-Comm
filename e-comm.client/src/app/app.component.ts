import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { LayoutComponent } from './Layout/layout/layout.component';
import { RouterOutlet } from '@angular/router';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
  }

}
