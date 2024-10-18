# Introduction

This test puts you in the role of having to work with someone else's code. It is highly suggested that you use test-first development with this exercise. 

# Background

Hi and welcome to team. As you know, we are a company dedicated to solving employees' time management problems. In this case we’re about to improve our allocations features. Allocations are the entities responsible for managing expiration and availability of days to be requested. These allocations can be of different categories (vacations, …) and are constantly increasing in availability as they approach their expiration date. The more days employees work the more days they have available to be requested. Availability drops to 0 after the expiration date. We have a system in place that updates availability for the allocations. The UpdateAvailability() method is called each morning by another part of our system. Your task is to add the new feature to our system so that we can begin managing a new category of allocations. First an introduction to our system:

- All allocations have an DaysToExpiration value which denotes the number of days the allocation expires
- All allocations have an Availability value which denotes the number of days available for being requested
- At the end of each day our system lowers DaysToExpiration value by 1 and increases Availability by 0.1 for every allocation

Pretty simple, right? Well, this is where it gets interesting:

- Availability drops to 0 after the expiration date
- The Availability of an allocation is never more than 20
- For “Vacation” allocations, once the expiration date has passed, availability is not set to 0 but decreases by 0.1
- "HomeWork" allocations actually decrease by 0.1 in Availability on each update.
- The Availability of an allocation is never negative
- "Sickness" never has to be expired or increases in Availability
- "RemoteWork", like home work, decreases in Availability as its Expiration approaches
  - Availability decreases by 0.2 when there are 10 days or less
  - Availability decreases by 0.3 when there are 5 days or less

# Instructions

We have recently created a new allocation category that requires an update to our system:

- "Compensated" allocations increase in Availability twice as fast as normal allocations

Feel free to make any changes to the UpdateAvailability method and add any new code as long as everything still works correctly. However, do not alter the Allocation class or Allocations property as those belong to another team that doesn't believe in shared code ownership (you can make the UpdateAvailability method and Allocations property static if you like, we'll cover for you).

Just for clarification, an allocation can never have its Availability increased above 20, however "Sickness" is a legacy allocation and as such its Availability is 25 and it never alters.

## Extra Credit

- Allocation categories are determined by whether they contain a given string in their name (e.g. "Vacation" or "Sickness" or "HomeWork")
- Any allocation can thus be compensated, with the resulting effects (e.g. "Compensated Vacation")

