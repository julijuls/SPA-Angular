import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { finalize } from "rxjs/operators"
import { TemperatureType, WeatherForecast, WeatherHistory } from '../../types/weather-forecast';



@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast | null = null;
  public zipCode: string;
  public loading: boolean;
  public temperatureType: TemperatureType = TemperatureType.Celcius;
  public error: string;
  public history: WeatherHistory[] | null = null;

  setTemperatureType(type: TemperatureType) {
    this.temperatureType = type;
  }

  onCodeInput(value) {
    this.zipCode = value
  }

  onRequestClick() {
    this.error = "";
    this.forecasts = null;
    this.loading = true;
    this._http.get<WeatherForecast>(this._baseUrl + 'weatherforecast/' + this.zipCode)
      .pipe(finalize(() => this.loading = false))
      .subscribe(
        (result: WeatherForecast) => {
          this.forecasts = result;
        },
        error => {
          this.error =
            "error loading weather for zipcode " + this.zipCode
        });
  }

  onHistoryClick() {
    this.error = "";
    this.history = null;

    this.loading = true;
    this._http.get<WeatherHistory[]>(this._baseUrl + 'weatherforecast/history')
      .pipe(finalize(() => this.loading = false))
      .subscribe(
        (result: WeatherHistory[]) => {
          this.history = result;
        },
        error => {
          this.error =
            "error loading history"
        });

  }


  constructor(private readonly _http: HttpClient, @Inject('BASE_URL') private readonly _baseUrl: string) {
    //http.get<WeatherForecast>(baseUrl + 'weatherforecast/94040').subscribe(result => {
    //  this.forecasts = result;
    //}, error => console.error(error));
  }
}

