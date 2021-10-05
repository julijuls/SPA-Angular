import { Component, Input } from "@angular/core";
import { TemperatureType, WeatherForecast } from "../../../types/weather-forecast";


const toCelcius = (temp: number): number => temp - 273.15;
const toFarenheit = (temp: number): number => 32 + toCelcius(temp) / 0.5556


@Component({
  selector: 'base-weather-info',
  templateUrl: './base-weather-info.component.html'
})
export class BaseWeatherInfoComponent {

  @Input() public forecastInfo: WeatherForecast | null = null;
  @Input() public temperatureType: TemperatureType = TemperatureType.Celcius;

  get Temperature() {
    switch (this.temperatureType) {
      case TemperatureType.Kelvin:
        return this.forecastInfo.temp + ' K';
      case TemperatureType.Celcius:
        return toCelcius(this.forecastInfo.temp).toPrecision(2) + ' C'
      case TemperatureType.Farengheit:
        return toFarenheit(this.forecastInfo.temp).toPrecision(2) + ' F'
      default:
        throw new Error("Unkwown temperature type");
    }
  }
}
