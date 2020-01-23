import React from 'react';
import './img.css';

const Img = (props) => {
  const images = props.images;

  return ( 
    <div className="img_container" >
      {images.map((imgSource, idx) =>
        <div key={idx}>
          <img  className="img_image_instance" src={imgSource} alt={`{idx}`} />
        </div>
      )}
    </div>
   );
}
 
export default Img;