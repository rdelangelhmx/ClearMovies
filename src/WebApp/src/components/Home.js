import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1 class='text-center'>Somos Clear</h1>
        <h2>Description of Code Sample:</h2>
        <p>Please send us a code sample on Github or another platform which demonstrates your skills in
          web development, both backend and frontend, and includes the use of the following
          technologies: .NET Framework / .NET Core, Entity Framework / Entity Framework Core, React.</p>
        <h2>Functional requirements:</h2>
        <ul>
          <li>Each movie must be associated with one or more actors. The search for a movie should work
            by title, genre, or actor name.</li>
          <li>The search result must be displayed on the same page below the search form.</li>
        </ul>
      </div>
    );
  }
}
