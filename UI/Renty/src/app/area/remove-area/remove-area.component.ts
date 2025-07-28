import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AreasService } from 'src/app/services/areas.service';
import { AreaDto } from 'src/app/types/area/AreaDto';

@Component({
  selector: 'app-remove-area',
  templateUrl: './remove-area.component.html',
  styleUrls: ['./remove-area.component.css']
})
export class RemoveAreaComponent implements OnInit {
  areas?: AreaDto[];
  
  constructor(private areasService: AreasService) { }

  ngOnInit(): void {
        this.areaForm.controls.area.disable();

    this.areasService.getAll().subscribe({
      next: (areas) => {
        this.areas = areas;
        console.log(this.areas);
            this.areaForm.controls.area.enable();
      },
      error: (error) => {
        console.error('Calling API failed', error);
      },
    })
  }

  areaForm = new FormGroup({
    area: new FormControl<number>(0, [
      Validators.required,
    ]),
    });
  
  RemoveArea(e: Event): void {
      e.preventDefault();
      if (this.areaForm.invalid) return;
    
      this.areasService.delete(this.areaForm.value.area!).subscribe({
        next: () => {
         alert("Deleted successfully");
             window.location.reload();
        },
        error: () => {
          alert('Deleted failed');
        },
      })
    }
  
}
