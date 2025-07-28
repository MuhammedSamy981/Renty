import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

async getCityFromCoordinates(lat: number, lon: number): Promise<string> {
  const response = await fetch(`https://us1.api-bdc.net/data/reverse-geocode-client?latitude=${lat}&longitude=${lon}&localityLanguage=en`);
  const data = await response.json();
  return data.city || 'Unknown location';
}


}