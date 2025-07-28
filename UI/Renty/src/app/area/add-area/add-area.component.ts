import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AreasService } from 'src/app/services/areas.service';
import { CitiesService } from 'src/app/services/cities.service';
import { AreaAddDto } from 'src/app/types/area/AreaAddDto';
import { CityDto } from 'src/app/types/city/CityDto';

@Component({
  selector: 'app-add-area',
  templateUrl: './add-area.component.html',
  styleUrls: ['./add-area.component.css']
})
export class AddAreaComponent implements OnInit {
  
  lastId?:number;
  cities?:CityDto[];
  
  constructor(private areasService: AreasService, private citiesService:CitiesService) { }

  ngOnInit(): void {

     this.areaForm.controls.city.disable();

    this.areasService.getAll()
    .subscribe(areas=> this.lastId = areas.length);

    this.citiesService.getAll().subscribe({
      next: (cities) => {
        this.cities = cities;
            this.areaForm.controls.city.enable();
      },
      error: (error) => {
        console.error('Calling API failed', error);
      },
    })
  }

  areaForm = new FormGroup({
      name: new FormControl<string>('', [
        Validators.required,
      ]),
      city: new FormControl<number>(0, [
            Validators.required,
      ]),
    });
  
  AddArea(e: Event): void {
      e.preventDefault();
      if (this.areaForm.invalid) return;

      const area: AreaAddDto =
      {
        id: this.lastId! + 1,
        name: this.areaForm.value.name!,
        cityId: this.areaForm.value.city as any
      };
    
      this.areasService.add(area).subscribe({
        next: () => {
         alert("Added successfully");
      window.location.reload();
    
        },
        error: () => {
          alert('Added failed');
        },
      })
    }
  
}
