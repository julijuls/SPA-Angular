export enum TemperatureType {
  Kelvin = 1,
  Celcius = 2,
  Farengheit = 3
}

export interface WeatherForecast {
  cityName: string;
  temp: number;
  timezone: string;
  icon: string;
}
export interface WeatherHistory extends WeatherForecast {
  id: number;
  datetimeRequest: Date;
}
