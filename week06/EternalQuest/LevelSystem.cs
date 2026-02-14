using System;
using System.Collections.Generic;
using System.Linq;

public class LevelSystem
{
    private int _level;
    private string _title;
    private int _currentScore;
    private Dictionary<int, string> _rankTitles;
    
    public LevelSystem()
    {
        _level = 0;
        _title = "Novice Seeker";
        _currentScore = 0;
        
        _rankTitles = new Dictionary<int, string>
        {
            {0, "Novice Seeker"},
            {5, "Pathfinder"},
            {10, "Goal Guardian"},
            {25, "Quest Champion"},
            {50, "Eternal Master"},
            {100, "Legendary Saint"},
            {200, "Celestial Hero"},
            {500, "Divine Exemplar"}
        };
    }
    
    public void UpdateLevel(int score)
    {
        _currentScore = score;
        _level = score / 100; // Every 100 points = 1 level
        UpdateTitle();
    }
    
    private void UpdateTitle()
    {
        // Find the highest rank the user has achieved based on level
        foreach (var rank in _rankTitles.OrderByDescending(r => r.Key))
        {
            if (_level >= rank.Key)
            {
                _title = rank.Value;
                return;
            }
        }
        
        // Default title if no ranks match (should not happen since we have rank 0)
        _title = "Novice Seeker";
    }
    
    public string GetRankInfo()
    {
        // Find the next rank to work towards
        int nextRankLevel = 0;
        foreach (var rank in _rankTitles.OrderBy(r => r.Key))
        {
            if (rank.Key > _level)
            {
                nextRankLevel = rank.Key;
                break;
            }
        }
        
        if (nextRankLevel > 0)
        {
            int pointsForNextLevel = (nextRankLevel * 100) - _currentScore;
            int levelsNeeded = nextRankLevel - _level;
            int pointsNeeded = (levelsNeeded * 100) - (_currentScore % 100);
            
            // Adjust if the calculation is negative
            if (pointsNeeded < 0) pointsNeeded = pointsForNextLevel;
            
            return $"Level {_level} - {_title} ({pointsNeeded} points to next rank: {_rankTitles[nextRankLevel]})";
        }
        else
        {
            // Already at max rank
            return $"Level {_level} - {_title} (Maximum rank achieved!)";
        }
    }
    
    public string GetSimpleRankInfo()
    {
        return $"Level {_level} - {_title}";
    }
    
    public int GetLevel()
    {
        return _level;
    }
    
    public string GetTitle()
    {
        return _title;
    }
}