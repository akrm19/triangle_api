import React from 'react';
import './results.css';

const Results = (props) => {
  const results = props.results;

  return ( 
    <>
    {results.length > 0 &&
      <pre className="getcoordinates_results_success">
        <code className="getcoordinates_results_code">
          {results}
        </code>
      </pre>
    }  
    </>
   );
}
 
export default Results;