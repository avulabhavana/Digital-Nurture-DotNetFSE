import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseCard } from '../../components/course-card/course-card';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [CommonModule, CourseCard],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseList {

  courses = [

    {
      title: 'Angular Fundamentals',
      instructor: 'John Smith',
      credits: 4,
      gradeStatus: 'passed',
      enrolled: true
    },

    {
      title: 'TypeScript Basics',
      instructor: 'Jane Doe',
      credits: 3,
      gradeStatus: 'pending',
      enrolled: false
    },

    {
      title: 'Web Development',
      instructor: 'David Miller',
      credits: 5,
      gradeStatus: 'failed',
      enrolled: true
    }

  ];

}
