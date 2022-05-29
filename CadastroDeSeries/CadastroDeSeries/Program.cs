var seriesRepository = new SeriesRepository();
var showHeader = true;

Main();


void Main()
{
	Dictionary<string, Action> menu = new Dictionary<string, Action>
	{
		{ "1", ListSeries },
		{ "2", ViewSeriesInfo },
		{ "3", InsertSeries },
		{ "4", UpdateSeries },
		{ "5", DeleteSeries },
		{ "C", ClearScreen},
		{ "X", ShowExitMessage }
	};

	while (true)
	{
		if (menu.TryGetValue(AskForAction(), out var action))
		{
			action();
			if (action == ShowExitMessage)
            {
				break;
            }
		}
		else
		{
			Console.WriteLine("Enter a valid option.");
		}
	} 
}

string AskForAction()
{
	if (showHeader)
    {
		Console.WriteLine("Welcome to DIO Series!!!");
		showHeader = false;
    }
	else
    {
        Console.WriteLine();
    }

    Console.WriteLine("Options:");

    Console.WriteLine("1 - List series");
    Console.WriteLine("2 - View series information");
    Console.WriteLine("3 - Insert new series");
    Console.WriteLine("4 - Update series");
    Console.WriteLine("5 - Delete series");
    Console.WriteLine("C - Clear screen");
    Console.WriteLine("X - Exit" + Environment.NewLine);

    Console.Write("Enter your choice: ");

    return Console.ReadLine().ToUpper().Trim();
}

void ListSeries()
{
	var list = seriesRepository.List;

	if (list.Count != 0)
	{
		list.ForEach(series => Console.WriteLine($"#ID {series.Id} - {series.Title} {(series.IsDeleted ? "*Deleted*" : "")}"));
	}
    else
    {
		Console.WriteLine("There aren't any series registered.");
    }
}

void ViewSeriesInfo()
{
	var series = GetSeries();
	if (series != null) Console.WriteLine(series);
}

Series? GetSeries()
{
	var chosenId = AskForID("series");

	if (chosenId != null)
    {
		var series = seriesRepository.GetById((int)chosenId);
        if (series == null) Console.WriteLine("There's no series with this ID.");
		return series;
	}
    else
    {
		return null;
    }
}

void InsertSeries()
{
	var series = CreateNewSeries(seriesRepository.NextId());

    if (series != null)
    {
		seriesRepository.Insert(series);
		Console.WriteLine("Inserted series with success.");
	}
}

void UpdateSeries()
{
	var oldSeries = GetSeries();
	if(oldSeries == null) return;
	var newSeries = CreateNewSeries(oldSeries.Id);

	if (newSeries != null)
    {
		seriesRepository.Update(newSeries);
		Console.WriteLine("Updated series with success.");
	}
}

void DeleteSeries()
{
	var series = GetSeries();

    if (series != null)
    {
		seriesRepository.Delete(series.Id);
		Console.WriteLine("Deleted series with success.");
	}
}

void ClearScreen()
{
	Console.Clear();
	showHeader = true;
}

void ShowExitMessage()
{
	Console.Write("Thanks for using our services.");
	Console.ReadLine();
}

int? AskForID(string idText)
{
	Console.Write($"Enter the {idText} ID: ");
	var isValidId = int.TryParse(Console.ReadLine().Trim(), out var id);

	if (isValidId)
	{
		return id;
	}
	else
	{
		Console.WriteLine($"Invalid {idText} Id.");
		return null;
	}
}

Series? CreateNewSeries(int id)
{
	var genre = AskForGenre();
	if (genre == null) return null;
	var title = AskForTitle();
	var releaseYear = AskForYear();
	if (releaseYear == null) return null;
	var synopsis = AskForSynopsis();

	return new Series(id, title, (Genre)genre, (int)releaseYear, synopsis);
}

int? AskForGenre()
{
	var genres = Enum.GetValues(typeof(Genre));
	ShowGenreMenu(genres);
	var genreId = AskForID("genre");

	if (genreId > 0 && genreId <= genres.Length)
	{
		return genreId;
	}
    else if (genreId != null)
    {
		Console.WriteLine("There's no genre with this ID.");
	}

	return null;
}

void ShowGenreMenu(Array genres)
{
	foreach (var genre in genres)
	{
		Console.WriteLine($"{(int)genre} - {genre}");
	}
	Console.WriteLine();
}

string AskForTitle()
{
	Console.Write("Enter the series title: ");
	return Console.ReadLine().Trim();
}

int? AskForYear()
{
	Console.Write("Enter the series release year: ");
	var isValidYear = int.TryParse(Console.ReadLine().Trim(), out var releaseYear);

	if (isValidYear)
	{
		return releaseYear;
	}
    else
    {
		Console.WriteLine("Invalid year.");
		return null;
    }
}

string AskForSynopsis()
{
	Console.Write("Enter the series synopsis: ");
	return Console.ReadLine().Trim();
}