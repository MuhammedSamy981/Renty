import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CountryDto } from '../types/country/CountryDto';
import { CountryAddDto } from '../types/country/CountryAddDto';
import { CountryUpdateDto } from '../types/country/CountryUpdateDto';

@Injectable({
  providedIn: 'root'
})

export class CountriesService {
private apiUrl = "http://localhost:5214/odata/Countries";
  constructor(private http:HttpClient) 
  { }

  public getAll():Observable<CountryDto[]>
  {
    return this.http.get<CountryDto[]>(this.apiUrl);
  }

  public getById(id:number):Observable<CountryDto>
  {
    return this.http.get<CountryDto>(this.apiUrl+"/"+id);
  }

  public add(country:CountryAddDto):Observable<object>
  {
    return this.http.post(this.apiUrl,country);
  }

  public update(country:CountryUpdateDto):Observable<object>
  {
    return this.http.put(this.apiUrl,country);
  }

  public delete(id:number):Observable<object>
  {
    return this.http.delete(this.apiUrl+"/"+id); 
  }
  
}
