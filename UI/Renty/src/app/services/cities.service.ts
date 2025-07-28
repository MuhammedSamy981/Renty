import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CityDto } from '../types/city/CityDto';
import { CityAddDto } from '../types/city/CityAddDto';
import { CityUpdateDto } from '../types/city/CityUpdateDto';

@Injectable({
  providedIn: 'root'
})

export class CitiesService {

  private apiUrl = "http://localhost:5214/odata/Cities";
  constructor(private http:HttpClient) 
  { }

  public getAll():Observable<CityDto[]>
  {
    return this.http.get<CityDto[]>(this.apiUrl);
  }

  public getAllByCountryId(id:number):Observable<CityDto[]>
  {
    return this.http.get<CityDto[]>(this.apiUrl+"/Country/"+id);
  }

  public getById(id:number):Observable<CityDto>
  {
    return this.http.get<CityDto>(this.apiUrl+"/"+id);
  }

  public add(city:CityAddDto):Observable<object>
  {
    return this.http.post(this.apiUrl,city);
  }

  public update(city:CityUpdateDto):Observable<object>
  {
    return this.http.put(this.apiUrl,city);
  }

  public delete(id:number):Observable<object>
  {
    return this.http.delete(this.apiUrl+"/"+id); 
  }
  
}
