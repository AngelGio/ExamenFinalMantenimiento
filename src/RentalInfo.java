import java.util.HashMap;

public class RentalInfo {

  private HashMap<String, Movie> movies;

  public RentalInfo() {
    movies = new HashMap<>();
    movies.put("F001", new Movie("You've Got Mail", "regular"));
    movies.put("F002", new Movie("Matrix", "regular"));
    movies.put("F003", new Movie("Cars", "childrens"));
    movies.put("F004", new Movie("Fast & Furious X", "new"));
  }

  public String statement(Customer customer) {
    double totalAmount = 0;
    int frequentEnterPoints = 0;
    String result = "Rental Record for " + customer.getName() + "\n";

    for (MovieRental r : customer.getRentals()) {
      double thisAmount = calculateAmount(r);
      frequentEnterPoints += calculateFrequentPoints(r);

      result += "\t" + getMovieTitle(r) + "\t" + thisAmount + "\n";
      totalAmount += thisAmount;
    }

    result += "Amount owed is " + totalAmount + "\n";
    result += "You earned " + frequentEnterPoints + " frequent points\n";

    return result;
  }

  private double calculateAmount(MovieRental rental) {
    Movie movie = movies.get(rental.getMovieId());
    double amount = 0;

    if (movie.getCode().equals("regular")) {
      amount = 2;
      if (rental.getDays() > 2) {
        amount += (rental.getDays() - 2) * 1.5;
      }
    } else if (movie.getCode().equals("new")) {
      amount = rental.getDays() * 3;
    } else if (movie.getCode().equals("childrens")) {
      amount = 1.5;
      if (rental.getDays() > 3) {
        amount += (rental.getDays() - 3) * 1.5;
      }
    }

    return amount;
  }

  private int calculateFrequentPoints(MovieRental rental) {
    Movie movie = movies.get(rental.getMovieId());
    int frequentPoints = 1;

    if (movie.getCode().equals("new") && rental.getDays() > 2) {
      frequentPoints++;
    }

    return frequentPoints;
  }

  private String getMovieTitle(MovieRental rental) {
    Movie movie = movies.get(rental.getMovieId());
    return movie.getTitle();
  }
}
