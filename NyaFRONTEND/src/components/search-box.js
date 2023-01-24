const SearchBox = ({className, placeholder, onChangeHandler}) => ( 
    <div className="searchBox">
        <div className="searchBoxHeader">
          <h1 id="attractionHeader" >All available attractions:</h1>
        </div>
         <input
        className={className}
        type='search'
        placeholder={placeholder}
        onChange={onChangeHandler}
        id="searchBoxInput" />

    </div>       
   
)

export default SearchBox