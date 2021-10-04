import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const toCelcius = (temp: number): number => temp - 273.15;
const toFarenheit = (temp: number): number => 32 + toCelcius(temp) / 0.5556

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast | null = null;
  public zipCode: string;
  public loading: boolean;
  private _temperatureType: TemperatureType = TemperatureType.Celcius;

  setTemperatureType(type: TemperatureType) {
    this._temperatureType = type;
  }

  onCodeInput(value) {
    this.zipCode = value
  }

  onRequestClick() {
    this.loading = true;
    this._http.get<WeatherForecast>(this._baseUrl + 'weatherforecast/' + this.zipCode)
      .subscribe(
        result => {
          this.forecasts = result;
        },
        error => console.error(error),
        () => this.loading = false);
  }

  get Temperature() {
    switch (this._temperatureType) {
      case TemperatureType.Kelvin:
        return this.forecasts.temp + ' K';
      case TemperatureType.Celcius:
        return toCelcius(this.forecasts.temp).toPrecision(2) + ' C'
      case TemperatureType.Farengheit:
        return toFarenheit(this.forecasts.temp).toPrecision(2) + ' F'
      default:
        throw new Error("Unkwown temperature type");
    }
  }

  constructor(private readonly _http: HttpClient, @Inject('BASE_URL') private readonly _baseUrl: string) {
    //http.get<WeatherForecast>(baseUrl + 'weatherforecast/94040').subscribe(result => {
    //  this.forecasts = result;
    //}, error => console.error(error));
  }
}

enum TemperatureType {
  Kelvin = 1,
  Celcius = 2,
  Farengheit = 3
}

interface WeatherForecast {
  cityName: string;
  temp: number;
  timezone: string;
  icon: string;
}
