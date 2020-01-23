import React from 'react';
import './Pages.css';
import imageWithTriangles from '../assets/imageWithTraingles.png';
import GetCoordinates from './GetCoordinates'
import Img from './Img';

const Home = () => {
  return ( 
    <div className='home_parent_container'>
      <h1 className="display-3 getcoordinates_title_text" >Triangles in Image Assignment</h1>
      <Img images={[imageWithTriangles]} />
      <GetCoordinates />
    </div>
   );
}
 
export default Home;