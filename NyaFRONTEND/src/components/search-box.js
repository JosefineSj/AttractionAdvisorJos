const SearchBox = ({className, placeholder, onChangeHandler}) => ( 
    <div className="searchBox">
        <h1>All available attractions:</h1>
         <input
        className={className}
        type='search'
        placeholder={placeholder}
        onChange={onChangeHandler}
        id="searchBoxInput" />

    </div>       
   
)

export default SearchBox