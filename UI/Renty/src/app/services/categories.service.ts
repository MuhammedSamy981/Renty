import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryDto } from '../types/category/CategoryDto';
import { CategoryAddDto } from '../types/category/CategoryAddDto';
import { CategoryUpdateDto } from '../types/category/CategoryUpdateDto';

@Injectable({
  providedIn: 'root'
})

export class CategoriesService {

  private apiUrl = "http://localhost:5214/odata/Categories";
  constructor(private http:HttpClient) 
  { }

  public getAll():Observable<any[]>
  {
    return this.http.get<any[]>(this.apiUrl);
  }

  public getById(id:number):Observable<CategoryDto>
  {
    return this.http.get<CategoryDto>(this.apiUrl+"/"+id);
  }

  public add(category:CategoryAddDto):Observable<object>
  {
    return this.http.post(this.apiUrl,category);
  }

  public update(category:CategoryUpdateDto):Observable<object>
  {
    return this.http.put(this.apiUrl,category);
  }

  public delete(id:number):Observable<object>
  {
    return this.http.delete(this.apiUrl+"/"+id); 
  }
  
}
