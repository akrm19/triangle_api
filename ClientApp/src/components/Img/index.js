import React from 'react';

const Img = (props) => {
  const source = props.imageSource;
  const style = {
    width: '37em'
  }
  return ( 
    <img className={style} src={source} alt='Table with triangles' />
   );
}
 
export default Img;