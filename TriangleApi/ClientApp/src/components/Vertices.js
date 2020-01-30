import React from 'react';
import './Pages.css';
import GetVertices from '../components/GetVertices';
import imageWithTriangles from '../assets/imageWithTraingles.png';
import triangle from '../assets/triangle.png';
import Img from './Img';

const Vertices = () => {
  return ( 
    <div className='home_parent_container'>
      <h1 className="display-3 getcoordinates_title_text" >Triangles in Image Assignment</h1>
      <div>
        <Img images={[triangle, imageWithTriangles]} />
      </div>

      <GetVertices />
    </div>   
   );
}
 
export default Vertices;