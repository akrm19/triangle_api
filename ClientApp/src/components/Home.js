import React from 'react';
import './Home.css';
import imageWithTriangles from '../assets/imageWithTraingles.png';
import GetCoordinates from './GetCoordinates/coordinates'

const Home = () => {
  return ( 
    <div className='home_parent_container'>
      <h1 className="display-3 getcoordinates_title_text" >Triangles in Image Assignment</h1>
      <img className='home_image_img' src={imageWithTriangles} alt='Table with triangles' />
      <div className='home_input_container' >
        <GetCoordinates />
      </div>
    </div>
   );
}
 
export default Home;